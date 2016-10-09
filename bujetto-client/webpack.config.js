/**
 * Created by Heapzilla on 10/8/2016.
 */
const path = require('path');
const merge = require('webpack-merge');
const webpack = require('webpack');
const NpmInstallPlugin = require('npm-install-webpack-plugin');

const TARGET = process.env.npm_lifecycle_event;
const PATHS = {
    app: path.join(__dirname, 'app'),
    build: path.join(__dirname, 'build')
};

process.env.BABEL_ENV = TARGET;

const common = {
    entry: {
        app: PATHS.app
    },
    // Add resolve.extensions.
    // '' is needed to allow imports without an extension.
    // note the .'s before extensions as it will fail to match without!
    resolve: {
        extensions: ['', '.js', '.jsx']
    },
    output: {
        path: PATHS.build,
        filename: 'bundle.js'
    },
    module: {
        loaders: [
            {
                //Test expects a RegExp! Note the slashes!
                test: /\.css$/,
                loaders: ['style', 'css'],
                //include accepts either a path or an array of paths
                include: [PATHS.app, path.join(PATHS.app, 'css')]
            },
            //Set up jsx. This accepts js too thanks to RegExp
            {
                test: /\.jsx?$/,
                //Enable caching for improved performance during development
                //it uses default OS directory by default.
                loaders: ['babel?cacheDirectory'],
                //Parse only app files! Without this it will go throught the entire project.
                //In addition to being slow, that will most likely result ine error.
                include: PATHS.app
            }
        ]
    }
};

if(TARGET === "start" || !TARGET) {
    module.exports = merge(common, {
        devtool: 'eval-source-map',
        devServer: {
            contentBase: PATHS.build,

            //Enable history API fallback so HTML5 History API based
            //routing works. This is a good default that will come
            //in handy in more complicated setups.
            historyApiFallback: true,
            hot: true,
            inline: true,
            progress: true,

            //Display only errors to reduce the amount of output
            stats: 'errors-only',

            //Parse host and port from env so this is easy to customize.
            host: process.env.HOST,
            port: process.env.PORT
        },
        plugins: [
            new webpack.HotModuleReplacementPlugin(),
            new NpmInstallPlugin({
                save: true // --save
            })
        ]
    });
}

if(TARGET === "build") {
    module.exports = merge(common, {});
}