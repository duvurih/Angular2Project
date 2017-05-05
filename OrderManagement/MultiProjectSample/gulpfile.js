var gulp = require('gulp');

var sass = require("gulp-sass");
var paths = {
    webroot: "./Content"
};
paths.scss = paths.webroot + "/**/*.scss";

gulp.task('sass', function () {
    gulp.src(paths.scss)
      .pipe(sass())
      .pipe(gulp.dest(paths.webroot));
});

gulp.task('watch-sass', function () {
    gulp.watch(paths.scss, ['sass']);
});


//const tscConfig = require('./tsconfig.json');
//var typescript = require('gulp-typescript');
//var tsProject = typescript.createProject(tscConfig);
//gulp.task('application', function () {
//    gulp.src(["./app"])
//    .pipe(typescript(tsProject))
//    .pipe(gulp.dest("./build"))
//});

gulp.task('default', ['sass', 'watch-sass']);
