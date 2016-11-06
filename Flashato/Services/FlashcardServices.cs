using Flashato.Domain;
using Flashato.Models.Requests;
using Flashato.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Flashato.Services
{
    public class FlashcardServices : IFlashcardServices
    {
        private IUserService _userService;

        public FlashcardServices(IUserService userService)
        {
            _userService = userService;
        }

        public int Insert(CardInsertRequest card)
        {
            int cardId = 0;
            string user = _userService.GetCurrentUserId();

            string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand("dbo.Flashcards_Insert", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Front", card.Front);
                    command.Parameters.AddWithValue("@Back", card.Back);
                    command.Parameters.AddWithValue("@UserId", user);

                    SqlParameter p = new SqlParameter("@Id", cardId);
                    p.Direction = ParameterDirection.Output;
                    command.Parameters.Add(p);

                    connection.Open();

                    command.ExecuteNonQuery();

                    int.TryParse(command.Parameters["@Id"].Value.ToString(), out cardId);
                }
            }
            return cardId;
        }

        public int Update(CardUpdateRequest card)
        {
            int cardId = 0;
            //string user = "patient0";

            string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Flashcards_Update", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", card.Id);
                    command.Parameters.AddWithValue("@Front", card.Front);
                    command.Parameters.AddWithValue("@Back", card.Back);

                    connection.Open();
                    command.ExecuteNonQuery();

                    int.TryParse(command.Parameters["@Id"].Value.ToString(), out cardId);
                }
            }
            return cardId;
        }

        public int Delete(int id)
        {
            int cardId = 0;

            string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Flashcards_SoftDelete",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();

                    int.TryParse(command.Parameters["@Id"].Value.ToString(), out cardId);
                }
            }
            return cardId;
        }

        public Flashcard GetById(int id)
        {
            Flashcard card = null;

            string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.Flashcards_SelectById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            IDataReader newRead = reader;
                            
                            int startingIndex = 0;

                            card = new Flashcard();

                            card.Id = newRead.GetInt32(startingIndex++);
                            card.Front = reader.GetString(startingIndex++);
                            card.Back = reader.GetString(startingIndex++);
                            card.UserId = reader.GetString(startingIndex++);
                            card.DateAdded = reader.GetDateTime(startingIndex++);
                            card.DateModified = reader.GetDateTime(startingIndex++);
                            
                        }
                    }
                }
            }
            return card;
        }

        public List<Flashcard> GetAllCards()
        {
            List<Flashcard> deck = null;

            string connectionString = WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand("dbo.Flashcards_SelectAllActive", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                IDataReader datReader = reader;
                                int startingIndex = 0;

                                Flashcard card = new Flashcard();

                                card.Id = datReader.GetInt32(startingIndex++);
                                card.Front = datReader.GetString(startingIndex++);
                                card.Back = datReader.GetString(startingIndex++);
                                card.UserId = datReader.GetString(startingIndex++);
                                card.DateAdded = datReader.GetDateTime(startingIndex++);
                                card.DateModified = datReader.GetDateTime(startingIndex++);

                                if (deck == null)
                                {
                                    deck = new List<Flashcard>();
                                }
                                deck.Add(card);
                            }
                            
                        }
                    }
                }
            }
            return deck;
        }

 
    
    }
}