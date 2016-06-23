import { API_CALL } from '../middleware/api'
 
export const FETCH_SUMMARYNEXTACTION_REQUEST = 'FETCH_SUMMARYNEXTACTION_REQUEST'
export const FETCH_SUMMARYNEXTACTION_SUCCESS = 'FETCH_SUMMARYNEXTACTION_SUCCESS'
export const FETCH_SUMMARYNEXTACTION_FAILURE = 'FETCH_SUMMARYNEXTACTION_FAILURE'

const fetchSummaryNextAction = (matterReference) => ({
  type: API_CALL,
  query: `{
            matter(reference:"` + matterReference + `") {
                milestones {
                  mileStoneName
                  actions {
                    taskName
                    dueBy
                  }
                }
              }
            }
        }`,
  selector: query => query.matter,
  onRequest: FETCH_SUMMARYNEXTACTION_REQUEST,
  onSuccess: FETCH_SUMMARYNEXTACTION_SUCCESS,
  onFailure: FETCH_SUMMARYNEXTACTION_FAILURE
})

export const fetchSummaryNextActionIfNeeded = () => (dispatch, getState) => {
  const summary = getState().summaryNextAction
  const matterReference = getState().selectedMatter.reference
  if (summary.loading)
    return
      
  return dispatch(fetchSummaryNextAction(matterReference))
}