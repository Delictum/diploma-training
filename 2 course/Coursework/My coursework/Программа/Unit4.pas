unit Unit4;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls, Vcl.OleCtrls,
  AcroPDFLib_TLB, DBXMySQL, Data.FMTBcd, Data.DB, Datasnap.DBClient,
  Datasnap.Provider, Data.SqlExpr;

type
  TFormPDF = class(TForm)
    AcroPDF1: TAcroPDF;
    Button1: TButton;
    Button2: TButton;
    OpenDialog1: TOpenDialog;
    SQLConnection1: TSQLConnection;
    SQLQuery1: TSQLQuery;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    procedure Button2Click(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  FormPDF: TFormPDF;

implementation

{$R *.dfm}

uses Unit1;

procedure TFormPDF.Button1Click(Sender: TObject);
Var ID_s : string;
    PicWithAPDF: Tmemorystream;
begin
  ID_s := Form1.DBGrid1.Fields[0].Value;
  if Button1.Caption = 'Изменить' then
    begin
      if OpenDialog1.Execute Then
        begin
          SQLQuery1.SQL.Text := 'UPDATE Drawing SET Image = :img WHERE ID = ' + ID_s;
          SQLQuery1.ParamByName('img').LoadFromFile(OpenDialog1.FileName, ftblob);
          SQLQuery1.ExecSQL;
        end;
    end
  else
    begin
      SQLQuery1.SQL.Text := 'UPDATE Drawing SET Image = NULL WHERE ID = ' + ID_s;
      SQLQuery1.ExecSQL;
    end;

      if FileExists('temp\buf.pdf') then
        DeleteFile('temp\buf.pdf');

      ID_s := Form1.DBGrid1.Fields[0].Value;
      Form1.ClientDataSet3.Active := false;
       Form1.SQLQuery3.Close;
        Form1.SQLQuery3.SQL.Clear;
         Form1.SQLQuery3.SQL.Add('SELECT * FROM Drawing WHERE ID = ' + ID_s);
          Form1.SQLQuery3.Open;
           Form1.ClientDataSet3.Active := true;
      PicWithAPDF := Tmemorystream.Create;
      TBLOBField(Form1.SQLQuery3.FieldByName('Image')).SaveToStream(PicWithAPDF);
      PicWithAPDF.Position := 0;
      PicWithAPDF.SaveToFile('temp\buf.pdf');
      FreeAndNil(PicWithAPDF);
      if FileExists('temp\buf.pdf') then
      FormPDF.acropdf1.LoadFile('temp\buf.pdf');
end;

procedure TFormPDF.Button2Click(Sender: TObject);
Var PicWithAPDF: Tmemorystream;
begin
  ID_s := Form1.DBGrid1.Fields[0].Value;
        begin
          SQLQuery1.SQL.Text := 'UPDATE Drawing SET Image = :img WHERE ID = ' + ID_s;
          SQLQuery1.ParamByName('img').LoadFromFile('temp\temp.pdf', ftblob);
          SQLQuery1.ExecSQL;
        end;
  FormPDF.Hide;
end;

end.
