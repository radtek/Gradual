// This file should be used if you want to debug
function jqGridInclude()
{
    var pathtojsfiles = "../Js/Lib/jQuery/Dev/jqgrid/"; // need to be ajusted

    // set include to false if you do not want some modules to be included
    var modules = [
        //{ include: false, incfile:'i18n/grid.locale-en.js'}, // jqGrid translation
        { include: true, incfile:'grid.base.js'}, // jqGrid base
        { include: true, incfile:'grid.common.js'}, // jqGrid common for editing
        { include: true, incfile:'grid.formedit.js'}, // jqGrid Form editing
        { include: true, incfile:'grid.inlinedit.js'}, // jqGrid inline editing
        { include: true, incfile:'grid.celledit.js'}, // jqGrid cell editing
        { include: true, incfile:'grid.subgrid.js'}, //jqGrid subgrid
        { include: true, incfile:'grid.treegrid.js'}, //jqGrid treegrid
        { include: true, incfile:'grid.custom.js'}, //jqGrid custom 
        { include: true, incfile:'grid.postext.js'}, //jqGrid postext
        { include: true, incfile:'grid.tbltogrid.js'}, //jqGrid table to grid 
        { include: true, incfile:'grid.setcolumns.js'}, //jqGrid setcolumns
        { include: true, incfile:'grid.import.js'}, //jqGrid import
        { include: true, incfile:'jquery.fmatter.js'}, //jqGrid formater
//        { include: true, incfile:'json2.js'}, //json utils
        { include: true, incfile:'jqModal.js'}, //xmljson utils
        { include: true, incfile:'jqDnR.js'}, //xmljson utils
        { include: true, incfile:'JsonXml.js'}, //xmljson utils
        { include: true, incfile:'grid.jqueryui.js'}, //xmljson utils
        { include: true, incfile:'jquery.searchFilter.js'} // search Plugin
    ];
    var filename;
    for(var i=0;i<modules.length; i++)
    {
        if(modules[i].include === true) {
        	
        	filename = pathtojsfiles+modules[i].incfile;
       		if(jQuery.browser.safari ) {
       			jQuery.ajax({url:filename,dataType:'script', async:false, cache: true});
       		} else {
				if (jQuery.browser.msie) {
        			document.write('<script type="text/javascript" src="'+filename+'"></script>');
       } else {

           //IncludeJavaScript(filename);
           document.writeln('<script type="text/javascript" src="' + filename + '"></script>');
				}
			}
        }
    }
    function IncludeJavaScript(jsFile)
    {
        var oHead = document.getElementsByTagName('head')[0];
        var oScript = document.createElement('script');
        oScript.type = 'text/javascript';
        oScript.charset = 'utf-8';
        oScript.src = jsFile;
        oHead.appendChild(oScript);        
    };
};
jqGridInclude();