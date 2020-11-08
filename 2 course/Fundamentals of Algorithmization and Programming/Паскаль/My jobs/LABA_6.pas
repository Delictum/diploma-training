Program Est;
Var mas:array[1..1000] of integer;
    max,min,i,y,k,s:integer;
 Begin
  s:=0;
  i:=0;
  writeln('Введите значения массива: ');
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
  writeln('MAX=',max,' и ','MIN=',min);
  for i:=1 to k do
     if mas[i]=max then
     s:=s+1;
  writeln('Количество max: ',s);
   begin
  y:=max;
  max:=min;
  min:=y;
  writeln('Max и min поменяли местами: ','MAX=',max,' и ','MIN=',min);
   end;
 end.