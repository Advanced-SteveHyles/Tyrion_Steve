export const SET_MATTER_REFERENCE = 'SET_MATTER_REFERENCE'

export const updateMatterReference = (reference) => {
    return { 
        type: SET_MATTER_REFERENCE, 
        reference: reference
    }
}