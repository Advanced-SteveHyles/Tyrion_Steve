import React from 'react'

export default (error) => {
    return (
        <div className='alert alert-danger'>
            {error}
        </div>
    )
}