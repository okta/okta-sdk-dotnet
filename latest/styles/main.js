// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.
function setVersions ()
{
	$.getJSON("/okta-sdk-dotnet/versions.json", data =>
	{
		let pathNameParts = window.location.pathname.split('/');
		let locationTag = pathNameParts[2];
		
		let versionSelect = $("#version-switcher");
		versionSelect.empty();
		data.versions.sort();
		$.each(data.versions, (index, value)=> 
		{
			if (value == locationTag)
				versionSelect.append("<option selected='selected'>" + value + "</option>");
			else
				versionSelect.append("<option>" + value + "</option>");
		})
	});	
	
    $('#version-switcher').change(function() {
        window.location = "/okta-sdk-dotnet/" + $(this).val() + "/index.html"
    });
};

$(document).ready(setVersions());