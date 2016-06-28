import { API_CALL } from '../middleware/api'

export const FETCH_PLANETS_REQUEST = 'FETCH_PLANETS_REQUEST'
export const FETCH_PLANETS_SUCCESS = 'FETCH_PLANETS_SUCCESS'
export const FETCH_PLANETS_FAILURE = 'FETCH_PLANETS_FAILURE'


export const fetchPlanets = () => {

       return ({
        type: API_CALL,
        query: `{
                    planet() {
                         name
                    }
                }`,
        selector: query => query.planet,
        onRequest: FETCH_PLANETS_REQUEST,
        onSuccess: FETCH_PLANETS_SUCCESS,
        onFailure: FETCH_PLANETS_FAILURE
    })

}


export const fetchPlanetsIfNeeded = () => (dispatch, getState) => {
  const planetsStore = getState().planetsStore
  if (planetsStore.loading)
    return
      
  return dispatch(fetchPlanets())
}