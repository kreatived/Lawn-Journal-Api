import React from "react";
import { HashRouter, Route, Link } from "react-router-dom";
import { Home } from './pages/home';
import { Lawns } from './pages/lawns';
import { Products } from './pages/products';

export const Main = () => {  
    return (
        <HashRouter>
            <div>
                <nav>
                    <li>
                        <Link to="/">Home</Link>
                    </li>
                    <li>
                        <Link to="/lawns">Lawns</Link>
                    </li>
                    <li>
                        <Link to="/products">Products</Link>
                    </li>
                </nav>

                <Route exact path="/" component = { Home }/>
                <Route path="/lawns" component = { Lawns }/>
                <Route path="/products" component = { Products }/>
            </div>
        </HashRouter>
    )
}