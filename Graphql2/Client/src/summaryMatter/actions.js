import { API_CALL } from '../middleware/api'
 
export const FETCH_SUMMARYMATTER_REQUEST = 'FETCH_SUMMARYMATTER_REQUEST'
export const FETCH_SUMMARYMATTER_SUCCESS = 'FETCH_SUMMARYMATTER_SUCCESS'
export const FETCH_SUMMARYMATTER_FAILURE = 'FETCH_SUMMARYMATTER_FAILURE'

const fetchSummary = (matterReference) => ({
  type: API_CALL,
  query: `{
            matter(reference:"` + matterReference + `") {
                reference
                description
                openDate

                debt {
                  claimNumber
                  dateOfService
                }

                feeEarner {
                  name
                  url{
                    value
                  }
                }
                
                supervisor {
                  name
                  url{
                    value
                  }
                }
            }
        }`,
  selector: query => query.matter,
  onRequest: FETCH_SUMMARYMATTER_REQUEST,
  onSuccess: FETCH_SUMMARYMATTER_SUCCESS,
  onFailure: FETCH_SUMMARYMATTER_FAILURE
})

export const get = () => (dispatch, getState) => {
  const summary = getState().summaryMatter
  const matterReference = getState().selectedMatter.reference
  if (summary.loading)
    return
      
  return dispatch(fetchSummary(matterReference))
}