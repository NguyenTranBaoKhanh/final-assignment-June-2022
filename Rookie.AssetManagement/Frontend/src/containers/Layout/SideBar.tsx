import React from "react";
import { NavLink } from "react-router-dom";
import {
  HOME, USER_LIST_LINK, USER
} from "src/constants/pages";
import Roles from "src/constants/roles";
import { useAppSelector } from "src/hooks/redux";
import { privateLinks, publicLinks } from "./NavLinks";

const SideBar = () => {
  const { account } = useAppSelector(state => state.authReducer);
  
  const isAdmin = account?.role==="Admin";
  
  return (
    <div className="nav-left mb-5">
      <img src='/images/Logo_lk.png' alt='logo' />
      <p className="brand intro-x">Online Asset Management</p>
      {publicLinks.map(page => (
        <NavLink key={page.link} className="navItem intro-x" to={page.link}>
          <button className="btnCustom">{page.title}</button>
        </NavLink>
      ))}
      
      {isAdmin&&(privateLinks.map(page => (
        <NavLink key={page.link} className="navItem intro-x" to={page.link}>
          <button className="btnCustom">{page.title}</button>
        </NavLink>
      )))}
    </div>
  );
};

export default SideBar;
