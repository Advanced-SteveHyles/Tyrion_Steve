//Adds part of the store to the props

export default (state, ownProps) => {
    return {
        ...state.planetsStore
    }
}

