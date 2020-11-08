program Project1;

uses
  Vcl.Forms,
  Unit1 in 'Unit1.pas' {Form1},
  Unit2 in 'Unit2.pas' {Form2},
  Unit4 in 'Unit4.pas' {FormPDF},
  Unit7 in 'Unit7.pas' {FormHelp},
  Unit5 in 'Unit5.pas' {FormStart};

{$R *.res}

begin
  Application.Initialize;
  Application.MainFormOnTaskbar := True;
  Application.CreateForm(TFormStart, FormStart);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TFormHelp, FormHelp);
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TFormPDF, FormPDF);
  Application.Run;
end.
