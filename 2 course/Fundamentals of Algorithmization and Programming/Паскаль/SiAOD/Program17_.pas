var
  a: array [1..20, 1..20] of longint;
  ans, t, l: array [1..20] of longint;
  n, i, j, answ: longint;

procedure Rec(x, k, s: longint);
var
  i: longint;

begin
  if s > answ then 
    exit;
  t[k] := x;
  if (k = n + 1) and (s > 0) then
  begin
    if s < answ
          Then 
    begin
      answ := s;
      ans := t;
    end;
    exit;
  end;
  
  inc(l[x]);
  
  if (k = n) and (a[x, 1] > 0) then
    Rec(1, k + 1, s + a[x, 1])
  else
    for i := 1 to n do
      if (a[x, i] > 0) and (l[i] = 0) then Rec(i, k + 1, s + a[x, i]);
  
  dec(l[x]);
end;



begin
  assign(input, '17.txt');
  reset(input);
  assign(output, 'output.txt');
  rewrite(output);
  read(n);
  fillchar(a, sizeof(a), 0);
  fillchar(l, sizeof(l), 0);
  answ := 1000000;
  
  for i := 2 to n do
    for j := 1 to n do
      read(a[i, j]);
  
  Rec(1, 1, 0);
  
  writeln(answ);
  for i := 1 to n do 
    write(ans[i], ' ');writeln(ans[n + 1]);
  close(input);
  close(output);
end.