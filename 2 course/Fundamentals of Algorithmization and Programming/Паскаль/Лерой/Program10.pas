{ генераци€ перестановок }
uses crt;
var
  a: array[1..8] of integer;
  j, n: integer;{счетчик}
  kol: longint;{количество перестановок}
  t: text;

procedure generate(l, r: integer; var k: longint);
var
  i, v: integer;
begin
  if (l = r) then
  begin
    for i := 1 to n do 
    begin
      write(a[i], ' ');
      
      assign(t, 'permutations.out.txt');
      Append(t);
      write(t, a[i], ' ');
      close(t);
    end;
    
    writeln;
    
    
    
    k := k + 1;
  end
  else
  begin
    for i := l to r do
    begin
      v := a[l]; a[l] := a[i]; a[i] := v; {обмен a[i],a[l]}
      generate(l + 1, r, k); {вызов новой генерации}
      v := a[l]; a[l] := a[i]; a[i] := v; {обмен a[i],a[l]}
      
      assign(t, 'permutations.out.txt');
      Append(t);
      writeln(t, ' ');
      close(t);
      
    end;
  end;
end;

begin
  clrscr;
  
  assign(t, 'permutations.out.txt');
  rewrite(t);
  close(t);
  
  while true do
  begin
    assign(t, 'permutations.in.txt');
    reset(t);
    readln(t, n);
    if n > 8 then
      writeln('¬ведите число меньше 8.')
    else
      break;
  end;
  close(t);
  
  for j := 1 to N do
    A[j] := j;
  generate( 1, n, kol);
  writeln;
  writeln('kol=', kol);
  readln
end.