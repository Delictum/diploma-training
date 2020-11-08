unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Data.DBXMySQL, Data.FMTBcd, Data.DB,
  Datasnap.DBClient, Datasnap.Provider, Data.SqlExpr, Vcl.StdCtrls, Vcl.DBCtrls,
  Vcl.Grids, Vcl.DBGrids, Vcl.Imaging.jpeg, Vcl.ExtCtrls;

type
  TForm1 = class(TForm)
    SQLConnection1: TSQLConnection;
    SQLTable1: TSQLTable;
    DataSetProvider1: TDataSetProvider;
    ClientDataSet1: TClientDataSet;
    DataSource1: TDataSource;
    SQLQuery1: TSQLQuery;
    ComboBox1: TComboBox;
    DBMemo1: TDBMemo;
    DBMemo2: TDBMemo;
    Image1: TImage;
    DataSource2: TDataSource;
    DataSetProvider2: TDataSetProvider;
    ClientDataSet2: TClientDataSet;
    SQLQuery2: TSQLQuery;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    DBMemo3: TDBMemo;
    DataSource3: TDataSource;
    ClientDataSet3: TClientDataSet;
    DataSetProvider3: TDataSetProvider;
    SQLQuery3: TSQLQuery;

    procedure ComboBox1Change(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.dfm}

uses Unit5;

procedure TForm1.Button1Click(Sender: TObject);
begin
form5.Button1.Caption := '��������';
form5.show;
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
form5.Button1.Caption := '�������';
form5.show;
end;

procedure TForm1.Button3Click(Sender: TObject);
begin
form5.Button1.Caption := '��������';
form5.show;
end;

procedure TForm1.ComboBox1Change(Sender: TObject);
begin
case combobox1.ItemIndex of
0: begin
 ClientDataSet2.Active := false;
  ClientDataSet3.Active := false;
  ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
          SQLQuery1.SQL.Add(' SELECT soderz2 FROM `glavi` ');
          SQLQuery1.Open;
          dbmemo1.DataField:='soderz2';
          ClientDataSet1.Active := true;

end;
1: begin
 ClientDataSet2.Active := false;
  ClientDataSet3.Active := false;
    ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
          SQLQuery1.SQL.Add(' SELECT soderz2 FROM glavi where id=2 ');
          SQLQuery1.Open;
          dbmemo1.DataField:='soderz2';
          ClientDataSet1.Active := true;
end;
   2: begin
        ClientDataSet1.Active := false;
         SQLQuery1.Close;
          SQLQuery1.SQL.Clear;
          SQLQuery1.SQL.Add(' SELECT �������� FROM paragraf where id=1  ');
          SQLQuery1.Open;
          dbmemo1.DataField:='��������';
          ClientDataSet1.Active := true;
          ClientDataSet2.Active := false;//����� �������
         SQLQuery2.Close;
          SQLQuery2.SQL.Clear;
          SQLQuery2.SQL.Add('SELECT ������ FROM ������� where id_zadanie=0   ');
          SQLQuery2.Open;
          dbmemo2.DataField:='������';
          ClientDataSet2.Active := true;
         SQLQuery3.Close;
          SQLQuery3.SQL.Clear;
          SQLQuery3.SQL.Add('select formuli from risunki where id_formula=1   ');
          SQLQuery3.Open;
          ClientDataSet3.Active := true
   end;
end;
end;

procedure TForm1.FormCreate(Sender: TObject);
begin
 ClientDataSet2.Active := false;
  ClientDataSet3.Active := false;
end;

end.
