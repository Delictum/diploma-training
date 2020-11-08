type
  ref = ^elem;
  elem = record
    pred: ref;
    next: ref;
    date: char;
  end;

var
  p, a, pa, ring, ring2, ring1: ref;
  d, buf, temp: char;
  i, j, h1, h2, h: integer;


procedure insertl(d: char; p: ref);
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
  h1 := 0;
  h2 := 0;
  new(p);
  p^.next := p;
  p^.pred := p;
  ring1 := p; 
  
  writeln('Введите элементы. Для завершения списка введите 1');
  readln(d);
  while d <> '1' do
  begin
    insertl(d, ring1^.pred);
    readln(d);
    inc(h1);
  end;
  
  Writeln('Стек 1: ');
  p := ring1^.pred;
  while p <> ring1 do
  begin
    write(p^.date:3);
    p := p^.pred;
  end;
  writeln; 
  //
  new(a);
  a^.next := a;
  a^.pred := a;
  ring2 := a; 
  
  writeln('Введите элементы. Для завершения списка введите 1');
  readln(d);
  while d <> '1' do
  begin
    insertl(d, ring2^.pred);
    readln(d);
    inc(h2);
  end;
  
  Writeln('Стек 2: ');
  a := ring2^.pred;
  while a <> ring2 do
  begin
    write(a^.date:3);
    a := a^.pred;
  end;
  writeln; 
  //
  new(pa);
  pa^.next := pa;
  pa^.pred := pa;
  ring := pa;
  
  p := ring1^.pred;
  a := ring2^.pred;
  for i := 1 to h1 do
  begin
    for j := 1 to h2 do
    begin    
      if (p^.date = a^.date) then
      begin        
        insertl(p^.date, ring^.pred);               
        inc(h);        
      end;
      a := a^.pred;
    end;    
    p := p^.pred; 
  end;
  
  Writeln('Полученный стек: ');
  pa := ring^.pred;
  while pa <> ring do
  begin
    write(pa^.date:3);
    pa := pa^.pred;
  end;
  writeln; 
end.