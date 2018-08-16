/*
 * jQuery Format Plugin v1.0
 * http://www.asual.com/jquery/format/
 *
 * Copyright (c) 2009 Rostislav Hristov
 * Uses code by Matt Kruse
 * Dual licensed under the MIT and GPL licenses.
 * http://docs.jquery.com/License
 *
 * Date: 2009-12-23 14:25:22 +0200 (Wed, 23 Dec 2009)
 */
(function(b){b.format=(function(){var e="undefined",d=true,f=false,c={date:{format:"dddd, MMMM dd, yyyy h:mm:ss tt",monthsFull:["January","February","March","April","May","June","July","August","September","October","November","December"],monthsShort:["Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"],daysFull:["Sunday","Monday","Tuesday","Wednesday","Thursday","Friday","Saturday"],daysShort:["Sun","Mon","Tue","Wed","Thu","Fri","Sat"],timeFormat:"h:mm tt",shortDateFormat:"M/d/yyyy",longDateFormat:"dddd, MMMM dd, yyyy"},number:{format:"#,##0.0#",groupingSeparator:",",decimalSeparator:"."}};return{locale:function(h){a={a:6};if(h){for(var i in h){for(var g in h[i]){c[i][g]=h[i][g]}}}return c},date:function(I,O){if(typeof I=="string"){var V=function(E,y,s,m){for(var i=m;i>=s;i--){var j=E.substring(y,y+i);if(j.length>=s&&(new RegExp(/^\d+$/)).test(j)){return j}}return null};if(typeof O==e){O=c.date.format}var q=false,L=0,l=0,R="",n="",v,u,g=new Date(),A=g.getYear(),U=g.getMonth()+1,T=1,h=g.getHours(),P=g.getMinutes(),J=g.getSeconds(),t=g.getMilliseconds(),D="";while(L<O.length){n="";R=O.charAt(L);while((O.charAt(L)==R)&&(L<O.length)){n+=O.charAt(L++)}if(n.indexOf("MMMM")>-1&&n.length>4){n="MMMM"}if(n.indexOf("EEEE")>-1&&n.length>4){n="EEEE"}if(n=="yyyy"||n=="yy"||n=="y"){if(n=="yyyy"){v=4;u=4}if(n=="yy"){v=2;u=2}if(n=="y"){v=2;u=4}A=V(I,l,v,u);if(A==null){return 0}l+=A.length;if(A.length==2){A=parseInt(A);if(A>70){A=1900+A}else{A=2000+A}}}else{if(n=="MMMM"){U=0;for(var K=0,r;r=c.date.monthsFull[K];K++){if(I.substring(l,l+r.length).toLowerCase()==r.toLowerCase()){U=K+1;l+=r.length;break}}if((U<1)||(U>12)){return 0}}else{if(n=="MMM"){U=0;for(var K=0,r;r=c.date.monthsShort[K];K++){if(I.substring(l,l+r.length).toLowerCase()==r.toLowerCase()){U=K+1;l+=r.length;break}}if((U<1)||(U>12)){return 0}}else{if(n=="EEEE"){for(var K=0,N;N=c.date.daysFull[K];K++){if(I.substring(l,l+N.length).toLowerCase()==N.toLowerCase()){l+=N.length;break}}}else{if(n=="EEE"){for(var K=0,N;N=c.date.daysShort[K];K++){if(I.substring(l,l+N.length).toLowerCase()==N.toLowerCase()){l+=N.length;break}}}else{if(n=="MM"||n=="M"){U=V(I,l,q?n.length:1,2);if(U==null||(U<1)||(U>12)){return 0}l+=U.length}else{if(n=="dd"||n=="d"){T=V(I,l,q?n.length:1,2);if(T==null||(T<1)||(T>31)){return 0}l+=T.length}else{if(n=="hh"||n=="h"){h=V(I,l,q?n.length:1,2);if(h==null||(h<1)||(h>12)){return 0}l+=h.length}else{if(n=="HH"||n=="H"){h=V(I,l,q?n.length:1,2);if(h==null||(h<0)||(h>23)){return 0}l+=h.length}else{if(n=="KK"||n=="K"){h=V(I,l,q?n.length:1,2);if(h==null||(h<0)||(h>11)){return 0}l+=h.length}else{if(n=="kk"||n=="k"){h=V(I,l,q?n.length:1,2);if(h==null||(h<1)||(h>24)){return 0}l+=h.length;h--}else{if(n=="mm"||n=="m"){P=V(I,l,q?n.length:1,2);if(P==null||(P<0)||(P>59)){return 0}l+=P.length}else{if(n=="ss"||n=="s"){J=V(I,l,q?n.length:1,2);if(J==null||(J<0)||(J>59)){return 0}l+=J.length}else{if(n=="SSS"||n=="SS"||n=="S"){t=V(I,l,q?n.length:1,3);if(t==null||(t<0)||(t>999)){return 0}l+=t.length}else{if(n=="a"){var F=I.substring(l,l+2).toLowerCase();if(F=="am"){D="AM"}else{if(F=="pm"){D="PM"}else{return 0}}l+=2}else{if(n!=I.substring(l,l+n.length)){return 0}else{l+=n.length}}}}}}}}}}}}}}}}}if(l!=I.length){return 0}if(U==2){if(((A%4==0)&&(A%100!=0))||(A%400==0)){if(T>29){return 0}}else{if(T>28){return 0}}}if((U==4)||(U==6)||(U==9)||(U==11)){if(T>30){return 0}}if(h<12&&D=="PM"){h=h-0+12}else{if(h>11&&D=="AM"){h-=12}}return(new Date(A,U-1,T,h,P,J,t))}else{var p=function(j,i){if(typeof i=="undefined"||i==2){return(j>=0&&j<10?"0":"")+j}else{if(j>=0&&j<10){return"00"+j}if(j>=10&&j<100){return"0"+j}return j}};if(typeof O==e){O=c.date.format}var u=I.getYear();if(u<1000){u=String(u+1900)}var o=I.getMonth()+1;var Q=I.getDate();var B=I.getDay();var z=I.getHours();var G=I.getMinutes();var C=I.getSeconds();var k=I.getMilliseconds();var I=new Object();I.y=u;I.yyyy=u;I.yy=String(u).substring(2,4);I.M=o;I.MM=p(o);I.MMM=c.date.monthsShort[o-1];I.MMMM=c.date.monthsFull[o-1];I.d=Q;I.dd=p(Q);I.EEE=c.date.daysShort[B];I.EEEE=c.date.daysFull[B];I.H=z;I.HH=p(z);if(z==0){I.h=12}else{if(z>12){I.h=z-12}else{I.h=z}}I.hh=p(I.h);I.k=z+1;I.kk=p(I.k);if(z>11){I.K=z-12}else{I.K=z}I.KK=p(I.K);if(z>11){I.a="PM"}else{I.a="AM"}I.m=G;I.mm=p(G);I.s=C;I.ss=p(C);I.S=k;I.SS=p(k);I.SSS=p(k,3);var L=0;var R="";var n="";var w="";var C=false;while(L<O.length){n="";R=O.charAt(L);if(R=="'"){L++;if(O.charAt(L)==R){w=w+R;L++}else{C=!C}}else{while(O.charAt(L)==R){n+=O.charAt(L++)}if(n.indexOf("MMMM")>-1&&n.length>4){n="MMMM"}if(n.indexOf("EEEE")>-1&&n.length>4){n="EEEE"}if(I[n]!=null&&!C){w=w+I[n]}else{w=w+n}}}return w}},number:function(u,y){if(typeof u=="string"){var q=c.number.groupingSeparator,k=c.number.decimalSeparator,h=u.indexOf(k),g=1;if(h!=-1){g=Math.pow(10,u.length-h-1)}u=u.replace(new RegExp("["+q+"]","g"),"");u=u.replace(new RegExp("["+k+"]"),".");return(parseInt(u*g))/g}else{if(typeof y==e||y.length<1){y=c.number.format}var z="",n="",q=",",A=y.lastIndexOf(q),k=".",h=y.indexOf(k);if(h!=-1){var n=c.number.decimalSeparator,s=y.substr(h+1).replace(/#/g,"").length,r=y.substr(h+1).length;if(r>0){var C=Math.pow(10,r),g=1000,j=String(Math.round(parseInt(u*C*g-parseInt(u)*C*g)/g)),t=u.toString().split(".");if(typeof t[1]!=e){for(var x=0;x<t[1].length;x++){if(t[1].substr(x,1)=="0"){j="0"+j}else{break}}}for(var x=0;x<(r-n.length);x++){j+="0"}var v,w="";for(var x=0;x<j.length;x++){v=j.substr(x,1);if(x>=s&&v=="0"){break}w+=v}n+=w}if(n==c.number.decimalSeparator){n=""}}if(h!=0){if(n!=""){z=String(Math.floor(u))}else{z=String(Math.round(u))}var B=c.number.groupingSeparator,m=0;if(A!=-1){if(h!=-1){m=h-A}else{m=y.length-A}m--}if(m>0){var o=0,p="",x=z.length;while(x--){if(o!=0&&o%m==0){p=B+p}p=z.substr(x,1)+p;o++}z=p}var D;if(h!=-1){D=y.substr(0,h).replace(new RegExp("#|"+B,"g"),"").length}else{D=y.replace(new RegExp("#|"+B,"g"),"").length}var l=z.length;for(var x=l;x<D;x++){z="0"+z}}result=z+n;return result}}}})()}(jQuery));


/*
Exemplos de formata��o:


    module("Dates");
    
    test("Basic requirements", function() {
        
        var d = new Date();
        var f = 'MMMM dd, yyyy KK:mm:ss:SSS a';
        var df = $.format.date(d, f);
        equals(d.getTime(), $.format.date(df, f).getTime());
        
        f = 'dd.MM.yyyy';
        df = $.format.date('1.5.2009', f);
        d = new Date(df);
        equals('01.05.2009', $.format.date(d, f));
               
        $.format.locale({
            date: {
                format: 'EEEE, \'o\'\'clock\' dd\' de \'MMMM\' de \'yyyy H:mm:ss',
                monthsFull: ['enero','febrero','marzo','abril','mayo','junio','julio','agosto','septiembre','octubre','noviembre','diciembre'],
                monthsShort: ['ene','feb','mar','abr','may','jun','jul','ago','sep','oct','nov','dic'],
                daysFull: ['domingo','lunes','martes','mi�rcoles','jueves','viernes','s�bado'],
                daysShort: ['dom','lun','mar','mi�','jue','vie','s�b'],
                timeFormat: 'H:mm:ss',
                shortDateFormat: 'dd/MM/yyyy',
                longDateFormat: 'EEEE, dd\' de \'MMMM\' de \'yyyy'
            }
        });

        d = new Date();
        d.setYear(1976);
        d.setMonth(4);
        d.setDate(31);
        d.setHours(3);
        d.setMinutes(20);
        d.setSeconds(43);
        d.setMilliseconds(0);

        equals('lunes, o\'clock 31 de mayo de 1976 3:20:43', $.format.date(d));
        
    });
    
    module("Number");
    
    test("Basic requirements", function() {
        
        equals('0.1230', $.format.number(0.123, '#0.0000'));
        equals('7,456.2', $.format.number(7456.2, '#,##0.0#'));
        equals('7,456.4', $.format.number(7456.351, '#,##0.#'));
        equals('123.40', $.format.number(123.4, '#,##0.00#'));
        equals('12.3241', $.format.number(12.32410, '#,##0.0000#'));
        equals('0.12321', $.format.number(0.123213, '#,##0.00###'));
        equals('2,101', $.format.number(2101.234, '#,###'));
        equals('102', $.format.number(101.7, '#,###'));
        equals('.1230', $.format.number(0.123, '.0000'));
        equals('.16', $.format.number(5.155, '.0#'));
        equals('540', $.format.number(540.23, '###'));
        equals('540', $.format.number(540.23, '###.'));
        equals('540', $.format.number(540, '###.##'));
        equals('19.03', $.format.number(19.03));
        equals('05.0303', $.format.number(5.0303, '00.0000'));

        equals('23,540.23', $.format.number(23540.23, '#,###.##'));
        equals('23,540', $.format.number(23540.23, '#,###'));
        equals('23540.230', $.format.number(23540.23, '#####.000'));
        equals('03.1', $.format.number(3.14, '#00.#'));
        equals('10.9', $.format.number(10.9, '#,##0.0#'));

        equals(0.123, $.format.number('.1230'));
        equals(86.02, $.format.number('86.02'));
        equals(3.14, $.format.number('03.14'));

        $.format.locale({
            number: {
                groupingSeparator: '.',
                decimalSeparator: ','
            }
        });
        
        equals('123,400', $.format.number(123.4, '#,##0.000'));
        equals('12,3241', $.format.number(12.32410, '#,##0.0000#'));
        equals('2.123,400', $.format.number(2123.4, '#,##0.000'));
        equals('1.231.231.212,3241', $.format.number(1231231212.32410, '#,##0.0000#'));
        
        equals(1231231212.3241, $.format.number('1.231.231.212,3241'));
        equals(18.005, $.format.number('18,00.5'));
        
        $.format.locale({
            number: {
                groupingSeparator: '\'',
                decimalSeparator: '.'
            }
        });
        
        equals('123.400', $.format.number(123.4, '#,##0.000'));
        equals('12.3241', $.format.number(12.32410, '#,##0.0000#'));
        equals("2'123.400", $.format.number(2123.4, '#,##0.000'));
        equals("1'231'231'212.3241", $.format.number(1231231212.32410, '#,##0.0000#'));
        
        equals(1231231212.3241, $.format.number("1'231'231'212.3241"));
        equals(18.005, $.format.number("18.00'5"));
        

*/