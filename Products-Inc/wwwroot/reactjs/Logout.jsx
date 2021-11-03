import { Component, Fragment } from 'react';
import React from 'React'
import {
    Redirect
} from 'react-router-dom';

export default function Logout({test, logoutCallback}) {
    
    const runlogout = () => {
    $.ajax({
        url: "/api/user/logout",
        type: "POST",
        contentType: "application/json",
        success: function (res) {
            logoutCallback();
        },
        error: function (jqXHR, textStatus, errorThrown) {
           
        }
    })

    }

        return (
                <button className="btn" onClick={() => runlogout()}>Logout</button>               
        )
    
}

