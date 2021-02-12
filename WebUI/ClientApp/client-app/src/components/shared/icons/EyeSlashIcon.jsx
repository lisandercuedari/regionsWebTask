import React from 'react'
import { FaEyeSlash } from 'react-icons/fa'
import styled from "styled-components"

const StyledEyeIcon = styled(FaEyeSlash)`
cursor: pointer;
`

export const EyeSlashIcon = ({ onClick }) => {
    return (
        <StyledEyeIcon onClick={onClick} />
    );
};
