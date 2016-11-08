/// <binding ProjectOpened='watch-sass' />
var gulp = require('gulp');
var sass = require('gulp-sass');

gulp.task('sass-compile', function () {
    gulp.src('./Content/Styles/style.scss')
        .pipe(sass())
        .pipe(gulp.dest('./Content/Styles'));
});

gulp.task('watch-sass', function () {
    gulp.watch('./Content/Styles/*.scss', ['sass-compile']);
});