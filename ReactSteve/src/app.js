import React from 'react'
import { render} from 'react-dom'
import {Router, Route, IndexRoute, hashHistory} from 'react-router'
import {Provider} from 'react-redux'
import {createStore, combineReducers} from 'redux'
import {syncHistoryWithStore, routerReducer} from 'react-router-redux'

import App from './components/App.jsx'
import DebtOverview from './components/DebtOverview.jsx'
import Ledger from './components/Ledger.jsx'
import Debts from './components/DebtsTable.jsx'

import { DebtsController } from './controllers'


// const store = createStore (
// 	 combineReducers ({		
// 		 ...reducers,
// 		 routing: routerReducer
// 	 })
// )

const history = syncHistoryWithStore(hashHistory, store)


render(
		<Router history={history}>
			<Route path="/" component={ App }>
				<IndexRoute component={ Debts } />
				<Route path="/overview/" component={DebtOverview} />
				<Route path="/ledger/" component={Ledger} />
			</Route>
		</Router> ,
	document.getElementById('content'));



// render(
// 	<Provider store={store}>
// 		<Router history={history}>
// 			<Route path="/" component={ App }>
// 				<IndexRoute component={ Debts } />
// 				<Route path="/overview/" component={DebtOverview} />
// 				<Route path="/ledger/" component={Ledger} />
// 			</Route>
// 		</Router> 
// 	</Provider>,
// 	document.getElementById('content'));
