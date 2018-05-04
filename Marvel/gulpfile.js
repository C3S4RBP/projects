var gulp = require('gulp'),
    log = require('fancy-log'),
    browserSync = require('browser-sync').create(),
    sass = require('gulp-sass'),
    pathComponents = 'app/components',
    pathCommon = 'app/common',
    filesJs = [
        pathComponents + '/favorites/js/*.js',
        pathComponents + '/favorites/*.js',
        pathComponents + '/list/js/*.js',
        pathComponents + '/list/*.js',
        pathCommon + '/header/js/*.js',
        pathCommon + '/header/*.js',
        '*.js'
    ],
    filesCss = [
        pathComponents + '/favorites/style/',
        pathComponents + '/list/style/',
        pathCommon + '/header/style/'
    ],
    filesSass = [
        pathComponents + '/favorites/style/*.scss',
        pathComponents + '/list/style/*.scss',
        pathCommon + '/header/style/*.scss',
    ],
    filesHtml = [
        pathComponents + '/favorites/view/*.html',
        pathComponents + '/list/view/*.html',
        pathCommon + '/header/view/*.html',
        'index.html'
    ]

gulp.task('serve', function () {
    browserSync.init({
        proxy: 'http://localhost/marvel'
    });
});
gulp.task('reload', function () {
    browserSync.reload();
})

gulp.task('sass', function () {
    gulp.src(filesSass, { base: '.' })
        .pipe(sass())
        .pipe(gulp.dest('.'));
    browserSync.reload();
});

gulp.task('watch', function () {
    gulp.watch(filesSass, ['sass']);
    gulp.watch(filesHtml, ['reload']);
    gulp.watch(filesJs, ['reload']);
});

gulp.task('servidor', ['watch', 'serve']);
gulp.task('archivos', ['sass']);