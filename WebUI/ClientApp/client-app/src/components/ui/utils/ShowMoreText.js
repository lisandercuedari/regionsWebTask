import React from 'react';

const ShowMoreText = (props) => {

    if (props.text.length > 25) {
        return <span>{props.text.substring(15) + '... '}<a>(show more)</a></span>
    }
    else {
        return <span>{props.text}</span>
    }
}

export default ShowMoreText;
