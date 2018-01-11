import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import ClientView from './components/ClientView';
import OAuth from './components/OAuth';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/oauth' component={ OAuth as any } />
    <Route path='/clientview' component={ ClientView as any } />
</Layout>;
