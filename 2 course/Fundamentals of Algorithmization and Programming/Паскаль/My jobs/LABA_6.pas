Program Est;
Var mas:array[1..1000] of integer;
    max,min,i,y,k,s:integer;
 Begin
  s:=0;
  i:=0;
  writeln('������� �������� �������: ');
   repeat
    i:=1+i;
    readln(mas[i]);
   until mas[i]=0;
  k:=i;
  max:=mas[1];
  min:=mas[1];
  for i:=1 to k do
     if mas[i]>max then max:=mas[i];
     if mas[i]<min then min :=mas[i];
  writeln('MAX=',max,' � ','MIN=',min);
  for i:=1 to k do
     if mas[i]=max then
     s:=s+1;
  writeln('���������� max: ',s);
   begin
  y:=max;
  max:=min;
  min:=y;
  writeln('Max � min �������� �������: ','MAX=',max,' � ','MIN=',min);
   end;
 end.