program dijkstra;
var
  G:array[1..100,1..100] of integer; {�������, �������� ����}
  Q,W:array[1..100]  of byte;        {������� � ������ �����}
  i,j:word;                         
  s:word;
  d:array[1..100] of word;           {������ ����������: ����� ���������� ������ d[i] - ���������� �� s �� i}
  p:array[1..100] of word;           {������ ���������}
  f:text;
  n:word;                            {����������� ������}
  nQ:word;
  nW:word;
  min,mI:word;
begin
  {������� ���������� ���������� �� ���������� �����}
  assign(f,'17.txt'); 
  reset(f);
  for i:=1 to 100 do
   for j:=1 to 100 do
     G[i,j]:=-1;
  read(f,n); readln(f,s);
  while not EOF(f) do
   begin
    read(f,i); read(f,j); readln(f,G[i,j]);
   end;
  close(f);
  {���������� ������� �� �����}
  
  for i:=1 to n do
   begin
    d[i]:=65535;
    p[i]:=0;
   end;
  d[s]:=0;
  for i:=1 to n do
   Q[i]:=i;
  nq:=n; nW:=0;
  
  while nq<>0 do
   begin
     min:=65535;
     for i:=1 to n do    {���� ������� � ����������� d[i]}
       if (Q[i]<>0) and (d[i]<min) then
         begin
          min:=d[i]; mI:=i;
         end;
     dec(nQ);            
     Q[mI]:=0;
     inc(nW); W[nW]:=mI;
     
     for j:=1 TO n DO
      if G[mi,j]<>-1 then
        if d[j]>d[Mi]+G[Mi,j] then
         begin
          d[j]:=d[mi]+g[mi,j];
          p[j]:=mi;
         end;
   end;
   
 {����� �� �����}  
 for i:=1 to n do
  writeln(d[i]);
end.