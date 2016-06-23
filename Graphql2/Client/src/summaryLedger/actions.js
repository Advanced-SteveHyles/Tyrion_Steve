import { API_CALL } from '../middleware/api'
 
export const FETCH_SUMMARYLEDGER_REQUEST = 'FETCH_SUMMARYLEDGER_REQUEST'
export const FETCH_SUMMARYLEDGER_SUCCESS = 'FETCH_SUMMARYLEDGER_SUCCESS'
export const FETCH_SUMMARYLEDGER_FAILURE = 'FETCH_SUMMARYLEDGER_FAILURE'

const fetchSummaryLedger = (matterReference) => ({
  type: API_CALL,
  query: `{
            matter(reference:"` + matterReference + `") {
                debt {
                  originalDebt
                  totalCosts
                  interest
                  disbursements
                  paidToDate
                  currentBalance
                }
            }
        }`,
  selector: query => query.matter,
  onRequest: FETCH_SUMMARYLEDGER_REQUEST,
  onSuccess: FETCH_SUMMARYLEDGER_SUCCESS,
  onFailure: FETCH_SUMMARYLEDGER_FAILURE
})

export const fetchSummaryLedgerIfNeeded = () => (dispatch, getState) => {
  const summaryLedger = getState().summaryLedger
  const matterReference = getState().selectedMatter.reference
  if (summaryLedger.loading)
    return
      
  return dispatch(fetchSummaryLedger(matterReference))
}