type
  ref = ^elem;
  elem = record
    pred: ref;
    next: ref;
    date: integer;
  end;

var
  p, ring: ref;
  d, i, h: integer;


procedure insertl(d: integer; p: ref);
var
  q: ref;
begin
  new(q);
  q^.date := d;
  q^.next := p^.next;
  q^.pred := p^.next^.pred;
  p^.next^.pred := q;
  p^.next := q
end;

procedure deletel(p: ref);

begin
  p^.next^.pred := p^.pred;
  p^.pred^.next := p^.next;
  dispose(p);
end;

begin
  h := 0;
  new(p);
  p^.next := p;
  p^.pred := p;
  ring := p; 
  
  writeln('Введите элементы. Для завершения списка введите -1');
  readln(d);
  while d <> -1 do
  begin
    insertl(d, ring^.pred);
    readln(d);
    inc(h);
  end;
  
  Writeln('Исходный список: ');
  p := ring^.next;
  while p <> ring do
  begin
    write(p^.date:3);
    p := p^.next;
  end;
  writeln; 
  
  p := ring^.next;
  for i := 1 to h do
  begin
    if (p^.date mod 3 = 0) and not (p^.date = 0) then
      deletel(p);
    p := p^.next;
  end;
  
  Writeln('Итоговый спиок: ');
  p := ring^.next;
  while p <> ring do
  begin
    write(p^.date:3);
    p := p^.next;
  end;
  writeln; 
end.