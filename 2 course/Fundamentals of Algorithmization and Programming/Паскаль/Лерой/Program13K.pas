uses crt;

const
  v = 8; 
  n = 2;
  inf = 100000;
  start = 1;

type
  vektor = array [1..V] of integer;

var
  distance: vektor;
  l, z, k: integer;
  visited: array[1..V]of boolean;

const
  GR: array [1..V, 1..V] of integer = 
 ((0, 8, 5, 4, 0, 0, 7, 0),  
  (0, 0, 0, 0, 0, 7, 4, 0), 
  (0, 0, 0, 0, 3, 0, 0, 4), 
  (0, 0, 0, 0, 5, 3, 0, 0),
  (0, 0, 0, 0, 0, 0, 0, 4),
  (0, 0, 0, 0, 0, 0, 0, 7),
  (0, 0, 0, 0, 5, 0, 0, 11),
  (0, 0, 0, 0, 0, 0, 0, 0));

procedure Dijkstra(st: integer);
var
  count, index, i, u, m, min: integer;
begin  
  m := st;  
  for i := 1 to V do  
  begin    
    distance[i] := inf;
    visited[i] := false;
  end;  
  distance[st] := 0;  
  for count := 1 to V - 1 do  
  begin
    z := 10 * n - 5;
    u := 0;
    min := inf;
    for i := 1 to V do      
      if (not visited[i]) and (distance[i] <= min) then      
      begin        
        min := distance[i];
        index := i;
      end;    
    u := index;
    visited[u] := true;
    l := z - 2;    
    for i := 1 to V do      
      if (not visited[i]) and (GR[u, i] <> 0) and (distance[u] <> inf) and      
      (distance[u] + GR[u, i] < distance[i]) then 
        distance[i] := distance[u] + GR[u, i]; 
  end;  
  write(' Стоимоть пути из начальной вершины до остальных ');
  writeln;
  k := 7;
  for i := 1 to V do    
    if distance[i] <> inf then      
      writeln(m, ' > ', i, ' = ', distance[i])    
    else writeln(m, ' > ', i, ' = ', ' маршрут недоступен ' );  
end;

begin
  clrscr;  
  write(' Начальная вершина >> ');
  writeln(start);
  Dijkstra(start);
  writeln(' Максимальный поток из узла s в узел t - ', l + k);   
end.