export default (state, ownProps) => {
    return {
        ...state.login,        
        isAuthenticated: state.token !== null
    }
}