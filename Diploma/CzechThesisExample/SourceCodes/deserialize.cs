using (var stream = await response.Content.ReadAsStreamAsync()){
  while (true){
    object[][] batch = null;
    batch = LZ4MessagePackSerializer.Deserialize<object[][]>(stream, true);
    if (batch is null) { break; }
    else{
      Application.Current.Dispatcher.Invoke(Data.AddRange(batch));
    }
  }
}