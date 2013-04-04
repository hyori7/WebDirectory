$(document).ready(function () {

    profile = document.getElementById('profileName').value;
    id = document.getElementById('profileID').value;


});
//redirecting only work outside of dom.load



function goImage() { 
    document.location.href = "../client/photo.aspx?profile=" + profile + "&id=" + id;
}

function goProfile() {
    document.location.href = "../client/profile.aspx?profile=" + profile + "&id=" + id;
}

function goUpload() {
    document.location.href = "../client/photo_upload.aspx?profile=" + profile + "&id=" + id;
}

function goNewProfile() {
    document.location.href = "../client/new_profile.aspx?profile=" + profile + "&id=" + id;
}

