program Project1;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {FormLog},
  Unit2 in 'Unit2.pas' {FormAir},
  Unit10 in 'Unit10.pas' {Form10},
  Unit3 in 'Unit3.pas' {FormAED},
  Unit7 in 'Unit7.pas' {FormHelp};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TForm10, Form10);
  Application.CreateForm(TFormAir, FormAir);
  Application.CreateForm(TFormLog, FormLog);
  Application.CreateForm(TFormAED, FormAED);
  Application.CreateForm(TFormHelp, FormHelp);
  Application.Run;
end.
