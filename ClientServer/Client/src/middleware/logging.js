export default store => next => action => {
    if(VERBOSE){console.log(action)}
    
    return next(action)
}