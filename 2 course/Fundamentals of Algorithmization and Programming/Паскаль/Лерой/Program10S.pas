const
  max = 10;

type
  mas = array [1..max + 1] of integer;//+1, иначе в строке
                                        //a[l+1]:=i выход за границы при n=max
var
  a: mas;

procedure Find(var a: mas; l: integer; n, m: integer; var t: text);
var
  i: integer;
begin
  if n = 0 then
  begin
    for i := l downto 1 do
    begin
      if i = 1 then
      begin
        write(t, a[i]);
        write(a[i]);
      end
      else
      begin
        write(t, a[i], '+');
        write(a[i], '+');
      end;
    end;
      writeln(t);
      writeln;
  end
  else
    if m > n then
      m := n;
      
  for i := 1 to m do
  begin
    a[l + 1] := i;
    Find(a, l + 1, n - i, i, t);
    end;
end;



var
  f, t: text;
  n: integer;

begin
  assign(f, 'input.txt');//файл в папке с программой
  reset(f);
  assign(t, 'output.txt');
  rewrite(t);
  read(f, n);
  close(f);
  Find(a, 0, n, n, t);
  close(t);
end.