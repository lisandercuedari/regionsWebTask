import React from 'react'
import { FaEye, FaEyeSlash } from 'react-icons/fa'
import styled from "styled-components"

const StyledEyeIcon = styled(FaEye)`
cursor: pointer;
`

const StyledEyeSlashIcon = styled(FaEyeSlash)`
cursor: pointer;
`

export const PasswordEyeIcon = ({ onClick, show }) => {
    let icon = show ? (<StyledEyeSlashIcon onClick={onClick} />) : (<StyledEyeIcon onClick={onClick} />);
    return (
        icon
    );
};
