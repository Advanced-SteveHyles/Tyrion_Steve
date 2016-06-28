
import React from 'react'
import { render} from 'react-dom'

import {createStore, combineReducers, applyMiddleware} from 'redux'
import {Provider} from 'react-redux'

import {Router, Route, IndexRoute, hashHistory} from 'react-router'
import {syncHistoryWithStore, routerReducer} from 'react-router-redux'
import * as Routes from './routes'

import App from './components/App'
import Summary from './components/Summary'
import Ledger from './ledger/Ledger'
import Documents from './components/Documents'
import FindDebts from './findDebts/FindDebts'
import LoginPage from './auth/LoginPage'
import LoggedInApp from './auth/LoggedInApp'

import Planets from './planets/Planets'

import { appInit } from './appinit'

import api from './middleware/api'
import authapi from './middleware/authapi'
import localStorage from './middleware/localStorage'

import thunk from 'redux-thunk'

import selectedMatterReducer from './selectedMatter/reducers'
import findDebtsReducer from './findDebts/reducers'
import summaryHeaderReducer from './summaryHeader/reducers'
import summaryMatterReducer from './summaryMatter/reducers'
import summaryLedgerReducer from './summaryLedger/reducers'
import summaryNextActionReducer from './summaryNextAction/reducers'
import tokenReducer from './auth/tokenReducer'
import loginPageReducer from './auth/loginPageReducer'
import sortedTableReducer from './sortedTable/reducers'
import ledgerReducer from './ledger/reducers'
import planetsReducer from './planets/reducers'

const store = createStore(
	combineReducers({
		findDebts: findDebtsReducer,
		selectedMatter: selectedMatterReducer,
		summaryMatter: summaryMatterReducer,
		summaryHeader: summaryHeaderReducer,
		summaryLedger: summaryLedgerReducer,
		summaryNextAction: summaryNextActionReducer,
		token: tokenReducer,
		login: loginPageReducer,
		routing: routerReducer, 
		sortedTable: sortedTableReducer,
		ledger: ledgerReducer,
		planetsStore: planetsReducer
	}),
	applyMiddleware(thunk, api, authapi, localStorage)
)

const history = syncHistoryWithStore(hashHistory, store)

store.dispatch(appInit())

render(
	<Provider store={store}>
		<Router history={history}>
			<Route path={Routes.root} component={ App }>
				<Route path={Routes.login} component={LoginPage}/>
				<Route component={LoggedInApp}>
					<IndexRoute component={ FindDebts } />
					<Route path={Routes.summary} component={Summary} />
					<Route path={Routes.ledger} component={Ledger} />
					<Route path={Routes.documents} component={Documents} />
					<Route path={Routes.planets} component={Planets} />}	
				</Route>
			</Route>
		</Router>
	</Provider>,
	document.getElementById('content'));
