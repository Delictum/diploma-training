program Est;
uses graphabc;
begin
ClearWindow(clOlive);
setwindowtitle ('Бульдозер');
rectangle(0,0,640,101);
FloodFill(10,40,clcyan);

setpencolor (clgreen);
setpenwidth (4);
line(550,110,590,110);
line(590,110,570,090);
line(570,090,550,110);
line(550,090,590,090);
line(590,090,570,070);
line(570,070,550,090);
line(550,070,590,070);
line(590,070,570,050);
line(570,050,550,070);
setpencolor (clbrown);
rectangle(565,115,575,130);
FloodFill(570,125,clbrown);
FloodFill(570,99,cllime);
FloodFill(570,105,cllime);
FloodFill(570,080,cllime);
FloodFill(570,060,cllime);{1 Elka}

setpencolor (clgreen);
line(500,110,540,110);
line(540,110,520,090);
line(520,090,500,110);
line(500,090,540,090);
line(540,090,520,070);
line(520,070,500,090);
line(500,070,540,070);
line(540,070,520,050);
line(520,050,500,070);
setpencolor (clbrown);
rectangle(515,115,525,130);
FloodFill(520,125,clbrown);
FloodFill(520,99,cllime);
FloodFill(520,105,cllime);
FloodFill(520,080,cllime);
FloodFill(520,060,cllime);{2 Elka}

setpencolor (clgreen);
line(450,110,490,110);
line(490,110,470,090);
line(470,090,450,110);
line(450,090,490,090);
line(490,090,470,070);
line(470,070,450,090);
line(450,070,490,070);
line(490,070,470,050);
line(470,050,450,070);
setpencolor (clbrown);
rectangle(465,115,475,130);
FloodFill(470,125,clbrown);
FloodFill(470,99,cllime);
FloodFill(470,105,cllime);
FloodFill(470,080,cllime);
FloodFill(470,060,cllime);{3 Elka}

setpencolor (clgreen);
line(400,110,440,110);
line(440,110,420,090);
line(420,090,400,110);
line(400,090,440,090);
line(440,090,420,070);
line(420,070,400,090);
line(400,070,440,070);
line(440,070,420,050);
line(420,050,400,070);
setpencolor (clbrown);
rectangle(415,115,425,130);
FloodFill(420,125,clbrown);
FloodFill(420,99,cllime);
FloodFill(420,105,cllime);
FloodFill(420,080,cllime);
FloodFill(420,060,cllime);{4 Elka}

setpencolor (clgreen);
line(350,110,390,110);
line(390,110,370,090);
line(370,090,350,110);
line(350,090,390,090);
line(390,090,370,070);
line(370,070,350,090);
line(350,070,390,070);
line(390,070,370,050);
line(370,050,350,070);
setpencolor (clbrown);
rectangle(365,115,375,130);
FloodFill(370,125,clbrown);
FloodFill(370,99,cllime);
FloodFill(370,105,cllime);
FloodFill(370,080,cllime);
FloodFill(370,060,cllime);{5 Elka}

setpencolor (clYellow);
Pie(100,100,50,180,0);
FloodFill(120,85,clYellow);{Солнце}

setpencolor (cllightgray);
line(125,100,525,480);
line(175,100,680,440);
FloodFill(600,460,clgray);{Дорога}

setpencolor (clblack);
circle(545,450,10);
FloodFill(550,450,cllightgray);
circle(450,370,10);
FloodFill(455,370,cllightgray);
line(460,370,540,440);
line(420,340,445,360);
line(420,340,465,330);
line(540,340,465,330);
line(540,340,620,395);
line(630,450,620,395);
line(630,450,610,475);
line(555,450,610,475);
line(460,370,535,340);
FloodFill(455,355,clblue);
line(550,440,620,400);
FloodFill(555,430,clblue);
FloodFill(610,410,clblue);
end.