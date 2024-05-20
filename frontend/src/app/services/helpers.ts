export const serializeLoginBody = (
  formatedName: string,
  formatedPassword: string
) => ({
  name: formatedName,
  password: formatedPassword,
});
