import path from 'path';
import HtmlWebpackPlugin from 'html-webpack-plugin';
const Dotenv = require('dotenv-webpack');

module.exports = () => {  

    return {
        entry: ['babel-polyfill', path.join(__dirname,'src','index.js')],  
        output: {    
        path: path.join(__dirname,'build'),    
        filename: 'index.bundle.js'  },  
        mode: process.env.NODE_ENV || 'development',  
        resolve: {    
            modules: [path.resolve(__dirname, 'src'), 'node_modules']  
        },  
        devServer: {    
            contentBase: path.join(__dirname,'src')  
        },  
        module: {    
            rules: [      
                {        
                    // this is so that we can compile any React,        
                    // ES6 and above into normal ES5 syntax        
                    test: /\.(js|jsx)$/,        
                    // we do not want anything from node_modules to be compiled        
                    exclude: /node_modules/,        
                    use: ['babel-loader']      
                },      
                {        
                    test: /\.(css|scss)$/,        
                    use: [          
                        "style-loader", 
                        // creates style nodes from JS strings          
                        "css-loader", 
                        // translates CSS into CommonJS          
                        "sass-loader" 
                        // compiles Sass to CSS, using Node Sass by default        
                    ]      
                },      
                {        
                    test: /\.(jpg|jpeg|png|gif|mp3|svg)$/,        
                    loaders: ['file-loader']      
                },
                {
                    test: /\.(woff(2)?|ttf|eot|svg)(\?v=\d+\.\d+\.\d+)?$/,
                    use: [{
                        loader: 'file-loader',
                        options: {
                            name: '[name].[ext]',
                            outputPath: 'fonts/'
                        }
                    }]
                } 
            ]  
        },  
        plugins: [    
            new HtmlWebpackPlugin({      
                template: path.join(__dirname,'src','index.html')    
            }),
            new Dotenv()
        ]
    }
};