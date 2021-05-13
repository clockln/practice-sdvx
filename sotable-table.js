
  const data = [
    {
      id: 0,
      name: 'Diamond',
      weight: 1.0,
      price: 9000,
    },
    {
      id: 1,
      name: 'Amethyst',
      weight: 3.0,
      price: 200,
    },
    {
      id: 2,
      name: 'Emerald',
      weight: 2.5,
      price: 2500,
    },
    {
      id: 3,
      name: 'Ruby',
      weight: 2.0,
      price: 2000,
    },
  ];

  const sortableTable = new SortableTable();
  // set table element
  sortableTable.setTable(document.querySelector('#my-table1'));
  // set data to be sorted
  sortableTable.setData(data);
  // handling events
  sortableTable.events()
      .on('sort', (event) => {
        console.log(`[SortableTable#onSort]
      event.colId=${event.colId}
      event.sortDir=${event.sortDir}
      event.data=\n${JSON.stringify(event.data)}`);
      });
