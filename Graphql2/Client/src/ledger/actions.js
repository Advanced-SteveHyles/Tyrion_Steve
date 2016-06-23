import { API_CALL } from '../middleware/api'

export const FETCH_LEDGER_REQUEST = 'FETCH_LEDGER_REQUEST'
export const FETCH_LEDGER_SUCCESS = 'FETCH_LEDGER_SUCCESS'
export const FETCH_LEDGER_FAILURE = 'FETCH_LEDGER_FAILURE'

const fetchLedger = (matterReference) => ({
  type: API_CALL,
  query: `{
            matter(reference:"` + matterReference + `") {
                ledger: clientLedger{
                    postingDate
                    postingRef
                    postingDescription
                    officeDebit
                    officeCredit
                    clientDebit
                    clientCredit
                    postingId
                    uniqueKey
                }
            }
        }`,
  selector: query => query.matter,
  onRequest: FETCH_LEDGER_REQUEST,
  onSuccess: FETCH_LEDGER_SUCCESS,
  onFailure: FETCH_LEDGER_FAILURE
})

export const fetchLedgerIfNeeded = () => (dispatch, getState) => {
  const ledger = getState().ledger
  const matterReference = getState().selectedMatter.reference
  if (ledger.loading)
    return

  return dispatch(fetchLedger(matterReference))
}