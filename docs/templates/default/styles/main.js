// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.
function setVersions ()
{
	$.getJSON("https://developer.okta.com/okta-sdk-dotnet/versions.json", data =>
	{
		let versionSelect = $("#version-switcher");
		versionSelect.empty();
		$.each(data.versions, (index, value)=> 
		{
			versionSelect.append("<option>" + value + "</option>");
		})
	});	
	
    $('#version-switcher').change(function() {
        window.location = "http://developer.okta.com/okta-sdk-dotnet/" + $(this).val() + "/index.html"
    });
};

$(document).ready(setVersions());