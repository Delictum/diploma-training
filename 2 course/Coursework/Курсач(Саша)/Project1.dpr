program Project1;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {FormMain},
  Unit2 in 'Unit2.pas' {Form2},
  Unit10 in 'Unit10.pas' {Form10};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm10, Form10);
  Application.CreateForm(TFormMain, FormMain);
  Application.CreateForm(TForm2, Form2);
  Application.Run;
end.
