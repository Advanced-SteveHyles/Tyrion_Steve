const isExpired = (token) => {
    return true;
}

export default (state, ownProps) => {
    return {
        isAuthenticated: state.token !== null,
        ...state
    }
}