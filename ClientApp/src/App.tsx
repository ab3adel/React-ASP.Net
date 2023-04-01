import * as React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import Home from './components/Home';
import {UpdateQuest} from './components/fetchdata/updatequest'
import {PostQ} from './components/fetchdata/postquest'
import NavMenu from './components/NavMenu';
import './css/custom.css'

export default () => (
    <Layout>
        <NavMenu/>
      
        <Route exact path='/' component={Home} />
        <Route exact path="/postquest" component={PostQ}/>
        <Route exact path="/updatequest/:id" component={UpdateQuest}/>
    </Layout>
);
