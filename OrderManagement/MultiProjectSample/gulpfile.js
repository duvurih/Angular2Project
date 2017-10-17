/// <binding Clean='clean' BeforeBuild='default1' />

//https://scotch.io/tutorials/how-to-use-browsersync-for-faster-development
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


const tscConfig = require('./tsconfig.json');
//var typescript = require('gulp-typescript');
//var tsProject = typescript.createProject(tscConfig);
gulp.task('application', function () {
    return gulp.src(["./app"])
    //.pipe(typescript(tsProject))
    .pipe(gulp.dest("./build"))
});

// broswer sync
var browserSync = require('browser-sync');
var _ = require('lodash');

gulp.task('browser-sync', function () {
    if (browserSync.active) {
        return;
    }
    var options = {
        proxy: 'localhost:' + 50381,
        port: 50381,
        files: [
            './app/**/*.*'
        ],
        ghostMode: {
            clicks: true,
            location: false,
            forms: true,
            scroll: true
        },
        injectChanges: true,
        logFileChanges: true,
        logLevel: 'debug',
        logPrefix: 'gulp-patterns',
        notify: true,
        reloadDelay: 1000
    };
    browserSync.init(options);
});

function notify(options) {
    var notifier = require('node-notifier');
    var notifyOptions = {
        sound: 'Bottle',
        contentImage: path.join(__dirname, 'gulp.png'),
        icon: path.join(__dirname, 'gulp.png')
    };
    _.assign(notifyOptions, options);
    notifier.notify(notifyOptions);
}

gulp.task('default', ['sass', 'watch-sass','browser-sync']);
