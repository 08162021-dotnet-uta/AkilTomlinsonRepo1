const registerform = document.querySelector(".registerform");

registerform.addEventListener('submit', (e) => {
  e.preventDefault();
  const FirstName = registerform.FirstName.value;
  const LastName = registerform.LastName.value;
  const userData = { CustomerId: -1, FirstName: FirstName, LastName: LastName }
  console.log(userData);
  fetch('customer/register', {
    method: 'POST',
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json'
    },
    body: JSON.stringify(userData)
  })
    .then(response => {
      console.log(response);
      if (!response.ok) {
        throw new Error(`Network response was not ok (${response.status})`);
      }
      else
        return response.json();
    })
    .then((jsonResponse) => {
      console.log(jsonResponse)
    })
    .catch(function (err) {
      console.log('Failed to fetch page: ', err);
    });
});