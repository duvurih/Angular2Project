/**
 * System configuration for Angular samples
 * Adjust as necessary for your application needs.
 */
(function (global) {
    System.config({
        paths: {
            // paths serve as alias
            'npm:': 'node_modules/'
        },
        // map tells the System loader where to look for things
        map: {
            // our app is within the app folder
            app: 'build',

            // angular bundles
            '@angular/core': 'npm:@angular/core/bundles/core.umd.js',
            '@angular/common': 'npm:@angular/common/bundles/common.umd.js',
            '@angular/compiler': 'npm:@angular/compiler/bundles/compiler.umd.js',
            '@angular/platform-browser': 'npm:@angular/platform-browser/bundles/platform-browser.umd.js',
            '@angular/platform-browser-dynamic': 'npm:@angular/platform-browser-dynamic/bundles/platform-browser-dynamic.umd.js',
            '@angular/http': 'npm:@angular/http/bundles/http.umd.js',
            '@angular/router': 'npm:@angular/router/bundles/router.umd.js',
            '@angular/forms': 'npm:@angular/forms/bundles/forms.umd.js',
            // other libraries
            'rxjs': 'npm:rxjs',
            'crypto-js': 'npm:crypto-js/crypto-js.js',
            'moment': 'npm:moment/',
            'lodash': 'npm:lodash/lodash.js',
            'ng2-bootstrap': 'npm:ng2-bootstrap',
            'ng2-table': 'npm:ng2-table',
            'ng2-modal': 'npm:ng2-modal',
            'ng2-page-scroll': 'npm:ng2-page-scroll',
            'symbol-observable': 'npm:symbol-observable',
            '@agm/core': 'npm:@agm/core/core.umd.js',
            '@angular-redux/store': 'npm:@angular-redux/store',
            '@angular-redux/router': 'npm:@angular-redux/router',
            'redux': 'npm:redux'
        },
        // packages tells the System loader how to load when no filename and/or no extension
        packages: {
            app: {
                main: 'main.js',
                defaultExtension: 'js'
            },
            rxjs: { defaultExtension: 'js' },
            'ng2-bootstrap': {format:'cjs', main: 'bundles/ng2-bootstrap.umd.js', defaultExtension: 'js' },
            'moment': { main: 'moment.js', defaultExtension: 'js' },
            'ng2-table': { defaultExtension: 'js' },
            'ng2-modal': { main: 'index.js', defaultExtension: 'js' },
            'ng2-page-scroll': { main: 'bundles/ng2-page-scroll.umd.js', defaultExtension: 'js' },
            'symbol-observable': { main: 'index.js', defaultExtension: 'js' },
            '@angular-redux/store': { main: 'lib/src/index.js', defaultExtension: 'js' },
            '@angular-redux/router': { main: 'lib/es5/index.js', defaultExtension: 'js' },
            redux: { main: 'dist/redux.min.js', defaultExtension: 'js' }
        }
    });
})(this);