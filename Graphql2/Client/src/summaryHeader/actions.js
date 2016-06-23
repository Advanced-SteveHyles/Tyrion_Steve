import { API_CALL } from '../middleware/api'

export const FETCH_SUMMARYHEADER_REQUEST = 'FETCH_SUMMARYHEADER_REQUEST'
export const FETCH_SUMMARYHEADER_SUCCESS = 'FETCH_SUMMARYHEADER_SUCCESS'
export const FETCH_SUMMARYHEADER_FAILURE = 'FETCH_SUMMARYHEADER_FAILURE'

const fetchHeader = (matterReference) => ({
  type: API_CALL,
  query: `{
            matter(reference:"` + matterReference + `") {
                description
                debtor : contact(roleName:"Debtor") {
                  name
                }
            }
        }`,
  selector: query => query.matter,
  onRequest: FETCH_SUMMARYHEADER_REQUEST,
  onSuccess: FETCH_SUMMARYHEADER_SUCCESS,
  onFailure: FETCH_SUMMARYHEADER_FAILURE
})

export const fetchHeaderIfNeeded = () => (dispatch, getState) => {
  const summary = getState().summaryHeader
  const matterReference = getState().selectedMatter.reference
  if (summary.loading)
    return

  return dispatch(fetchHeader(matterReference))
}