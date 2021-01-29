// Copyright (c) Microsoft. All rights reserved. Licensed under the MIT license. See LICENSE file in the project root for full license information.
function setVersions ()
{
	$.getJSON("/versions.json", data =>
	{
		let versionSelect = $("#version-switcher");
		versionSelect.empty();
		$.each(data.versions, (index, value)=> 
		{
			versionSelect.append("<option>" + value + "</option>");
		})
	});	
	
    $('#version-switcher').change(function() {
        window.location = $(this).val() + "/index.html"
    });
};

$(document).ready(setVersions());