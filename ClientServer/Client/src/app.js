import 'babel-polyfill'
import React from 'react'
import { render} from 'react-dom'

import {createStore, combineReducers, applyMiddleware} from 'redux'
import {Provider} from 'react-redux'

import {Router, Route, IndexRoute, hashHistory} from 'react-router'
import {syncHistoryWithStore, routerReducer} from 'react-router-redux'
import * as Routes from './routes'

import App from './components/App'
import LoginPage from './auth/LoginPage'
import LoggedInApp from './auth/LoggedInApp'
import loggedInUserReducer from './auth/tokenReducer'
import loginPageReducer from './auth/loginPageReducer'

const store = createStore(
	combineReducers({
		loggedInUser: loggedInUserReducer,
		login: loginPageReducer,
	}),
//	applyMiddleware(thunk, authapi, facadeApi, logging)
)

const history = syncHistoryWithStore(hashHistory, store)

render(
	<Provider store={store}>
		<Router history={history}>
			<Route path={Routes.root} component={ App }>
				<Route path={Routes.login} component={LoginPage}/>
				<Route component={LoggedInApp}>					
				</Route>
			</Route>
		</Router>
	</Provider>,
	document.getElementById('content'));
