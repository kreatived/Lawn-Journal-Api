import React from "react";
import { HashRouter, Route } from "react-router-dom";
import { Home } from './pages/home';
import { Lawns } from './pages/lawns';
import { Products } from './pages/products';
import { Nav } from './pages/shared/nav';
import { LawnDetail } from "./pages/lawnDetail";

export const Main = () => {  
    return (
        <div>
            <HashRouter>
                <Nav />

                <main role="main">
                    <Route exact path="/" component = { Home }/>
                    <Route exact path="/lawns" component = { Lawns }/>
                    <Route path="/products" component = { Products }/>
                    <Route path="/lawns/:lawnId" component = { LawnDetail }/>
                </main>
            </HashRouter>
        </div>
    )
}